using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISM6225_Assignment4.Models
{
    public class FishingArea
    {
        public Attributes attributes { get; set; }
        public Geometry geometry { get; set; }

    }


    public class Geometry
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class Attributes 
    {
        public int id { get; set; }

        public string WaterBody { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string Owner { get; set; }

        public string Manager { get; set; }

        public string AccessType { get; set; }

        public string BoatSize { get; set; }

        public string RampType { get; set; }

        public string UniversalAccess { get; set; }
    }

    public class FishingAreas
    {
        public FishingArea getFishingArea(int id)
        {
            foreach (FishingArea fishingArea in data)
            {
                if(fishingArea.attributes.id == id)
                {
                    return fishingArea;
                }
            }

            return null;
        }
        public List<FishingArea> data { get; set; }
    }
}
