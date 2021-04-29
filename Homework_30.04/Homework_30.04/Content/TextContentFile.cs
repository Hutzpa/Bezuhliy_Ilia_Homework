namespace Homework_30._04.Content
{
    public class TextContentFile : ContentFile
    {
        public string Content { get; set; }

        public override string ToString()
        {
            return $" \t {FileName}.{FileExtension} \n \t\t Extension: {FileExtension} \n \t\t Size: {Weight}{WeightMark} \n \t\t Content: {Content} \n";
        }
    }
}
