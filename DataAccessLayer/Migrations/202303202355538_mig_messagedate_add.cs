namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messagedate_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Messages", "MessageStatus");
            DropTable("dbo.Drafts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        DraftId = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        MessageContent = c.String(),
                    })
                .PrimaryKey(t => t.DraftId);
            
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "MessageDate");
        }
    }
}
