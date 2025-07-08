using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonPhaseApp
{
    public class PostData
    {
        public string? date	{ get; set; } = "";
        public int? timestamp { get; set; } = 0;
        public string? phase { get; set; } = "";
        public string? illumination { get; set; } = "";
        public string? moon_age { get; set; } = "";
        public string? moon_image { get; set; } = "";
        public float? moon_angle { get; set; } = 0;
        public string? moon_distance { get; set; } = "";
        public string? sun_distance { get; set; } = "";
        public string? moon_sign { get; set; } = "";
        public string? moon_zodiac { get; set; } = "";
    }
}
