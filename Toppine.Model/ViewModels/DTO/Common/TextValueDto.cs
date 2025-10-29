using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppine.Model.ViewModels.DTO
{
    public class IDDescriptionDto
    {
        public string ID { get; set; }
        public string Description { get; set; }
    }

    public class IntIDDescriptionDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }

    public class IntIDValueDescriptionDto
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public class TextValueDto
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public bool Selected { get; set; }
    }

    public class TextIDValueDto
    {
        public string ID { get; set; }
        public string Description { get; set; }

        public string Value { get; set; }

        public string Category { get; set; }  //SubCon inventory
    }



    public class TextINTValueDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }


    public class ValueDescriptionDto
    {

        public string Value { get; set; }
        public string Description { get; set; }
    }
}
