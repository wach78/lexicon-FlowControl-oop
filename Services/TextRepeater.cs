using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Ovn2_FlowControl.Enums.Services
{
    internal class TextRepeater
    {
        public TextRepeater(int firstRepeatNumber, int repeatCount)
        {
            if (firstRepeatNumber < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(firstRepeatNumber),
                    "First repeat number must be at least 1."
                );
            }

            if (repeatCount < firstRepeatNumber)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(repeatCount),
                    "Repeat count must be greater than or equal to first repeat number."
                );
            }

            FirstRepeatNumber = firstRepeatNumber;
            RepeatCount = repeatCount;
        }

        public int FirstRepeatNumber { get; }

        public int RepeatCount { get; }

        
        public void RepeatText(string text)
        {
            string separator = ", ";
            for (int number = FirstRepeatNumber; number <= RepeatCount; number++)
            {
                if (number == RepeatCount)
                {
                    separator = ".";
                }

                Console.Write($"{number}.{text}{separator}");
            }

            Console.WriteLine();
        }
    }
}
