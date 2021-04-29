using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_30._04.Content
{
    public abstract class ContentFile
    {
        public FileType Type { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int Weight { get; set; }
        public string WeightMark { get; set; }
    }
    public enum FileType
    {
        Text,
        Image,
        Movie
    }


}
