using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;

namespace Voting.Data.NHibernate.Mappings
{
    public class OptionMap : ClassMap<Option>
    {
        public OptionMap()
        {
            Id(x => x.Id, "Id").GeneratedBy.Assigned();
            Map(x => x.Key, "`Key`");
            Map(x => x.Value);
           // Map(x => x.QuestionId);
            Table("Options");

            References(x => x.Question)
                .Column("QuestionId")
                .Not.Nullable();

            HasMany(x => x.Votes)
               .Inverse()
               .Cascade.All()               
               .KeyColumn("OptionId");
        }
    }
}
