using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Domain.QuestionAggregate
{
    enum QuestionState
    {
        BeingPrepared = 1,
        Asked = 2,
        Closed = 3
    }
}
