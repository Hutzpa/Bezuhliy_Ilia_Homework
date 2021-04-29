﻿namespace Homework_30._04.Content
{
    public class MovieContentFile : ContentFile
    {
        public string Resolution { get; set; }
        public string Length { get; set; }

        public override string ToString()
        {
            return $" \t {FileName}.{FileExtension} \n \t\t Extension: {FileExtension} \n \t\t Size: {Weight}{WeightMark} \n \t\t Resolution: {Resolution} \n \t \t Length: {Length}";
        }
    }
}