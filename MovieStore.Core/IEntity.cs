﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
