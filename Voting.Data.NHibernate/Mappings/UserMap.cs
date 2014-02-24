using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.UserAggregate;

namespace Voting.Data.NHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id, "Id").GeneratedBy.Assigned();
            Map(x => x.Name);
            Map(x => x.Points);
            Table("Users");
        }
    }
}
