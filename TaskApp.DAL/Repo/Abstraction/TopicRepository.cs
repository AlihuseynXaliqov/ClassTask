﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Model;
using TaskApp.DAL.Context;
using TaskApp.DAL.Repo.Interface;

namespace TaskApp.DAL.Repo.Abstraction
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(AppDbContext context) : base(context)
        {
        }
    }
}
