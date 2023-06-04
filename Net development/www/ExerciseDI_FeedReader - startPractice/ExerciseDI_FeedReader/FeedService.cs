using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseDI_FeedReader
{
    public class FeedService
    {
        IFeedService _medium;

        public FeedService(IFeedService medium)
        {
            _medium = medium;
        }
        public string GetFeed()
        {
           return _medium.GetSingleFeed();
        }
    }
}
