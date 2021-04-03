using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category: IEntity

    //classlara inheritance ayda implement almalı ilerisi için 
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
