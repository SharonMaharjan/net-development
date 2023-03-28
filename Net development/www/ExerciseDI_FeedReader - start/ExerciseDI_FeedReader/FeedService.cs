using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseDI_FeedReader
{
    public class FeedService
    {


        private readonly IFeedService _service;

        public FeedService(IFeedService service)
        {
            _service = service;
        }

        public string GetFeed()
        {
             return _service.GetSingleFeed() ;      
        }
    }
}
