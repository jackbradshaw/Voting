using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;
using Voting.Domain.UserAggregate;

namespace Voting.Data.NHibernate.Mappings
{
    public class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id, "Id").GeneratedBy.Assigned();
            Map(x => x.Text);
            Map(x => x.State);
            Table("Questions");

            References(i => i.Asker)                
               .Column("AskerId")
               .Not.Nullable();

            HasMany(x => x.Options).Inverse().Cascade.All().KeyColumn("QuestionId");
           
        }
    }
}
