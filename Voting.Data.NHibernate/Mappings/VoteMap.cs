using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;

namespace Voting.Data.NHibernate.Mappings
{
    public class VoteMap : ClassMap<Vote>
    {
        public VoteMap()
        {
            CompositeId()
                .KeyReference(x => x.Option,"OptionId")
                .KeyReference(x => x.Voter, "VoterId");

            //Map(x => x.OptionId);
            //Map(x => x.VoterId);
            Table("Votes");

            //References(i => i.Voter)
            //    .Column("VoterId")
            //    .Not.Nullable();

            //References(i => i.Option)
            //    .Column("OptionId")
            //    .Not.Nullable();  
           
        }
    }
}