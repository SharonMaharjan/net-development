﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseDI_FeedReader
{
    public interface IFeedService
    {
         string ReturnType { get; }

        string GetSingleFeed();

    }
}
