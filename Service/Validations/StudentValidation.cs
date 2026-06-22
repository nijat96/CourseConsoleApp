using Repository.Repositories.Implementation;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validations
{
    public static class StudentValidation
    {
        public static bool CheckStudentGroupId(int id, GroupService groupService)
        {
            if(!groupService.GetAllGroups().Select(x=>x.Id).Contains(id))
            {
                return false;
            }
            return true;
        }
    }
}
