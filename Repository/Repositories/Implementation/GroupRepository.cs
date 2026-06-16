using Domain.Entities;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.Implementation
{
    public class GroupRepository : IRepository<Group>
    {
        public void Add(Group entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public Group Get(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
