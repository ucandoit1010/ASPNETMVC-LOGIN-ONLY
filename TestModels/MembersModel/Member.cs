using System;


namespace TestModels.MembersModel
{
    public class Members
    {
        public Guid MemberId { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

    }

}
