using System;
using TestModels.MembersModel;

namespace BusinessLayer.BLMembers
{
    public interface IMemberRepository
    {
        bool AddMember(Members member);
        bool IsMemberExists(Members member);
        Members GetMember(Members member);


    }
}
