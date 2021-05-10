﻿using System;

namespace Homework_30._04.Content
{
    public class MovieContentFile : ContentFile, IResolution
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public TimeSpan Duration { get; set; }

        public override string ToString()
        {
            return $" \t {FileName}.{FileExtension} \n \t\t Extension: {FileExtension} \n \t\t Size: {Weight}{WeightMark} \n \t\t Resolution: {Width}x{Height} \n \t \t Length: {Duration.Hours}h{Duration.Minutes}m";
        }
    }
}
