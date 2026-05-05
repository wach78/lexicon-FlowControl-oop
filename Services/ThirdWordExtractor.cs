using System;

namespace Ovn2_FlowControl.Services
{
    internal class ThirdWordExtractor
    {
        public ThirdWordExtractor(string? text)
        {

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Text can not be empty.", nameof(text));
            }

            Text = text;

            GetWords();
        }

        public string Text { get; }

        private string[] GetWords()
        {
            return Text.Split(
                   ' ',
                   StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
               );
        }

        public override string ToString()
        {
            string[] words = GetWords();

            if (words.Length < 3)
            {
                throw new InvalidOperationException("Text must contain at least 3 words.");
            }

            return words[2];
        }
    }
}
