﻿using Microsoft.VisualStudio.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace CsInlineColorViz
{
    internal sealed class ColorTagger : RegexTagger<ColorTag>
    {
        internal ColorTagger(ITextBuffer buffer)
            : base(buffer, new[] { new Regex(@"(Color|ConsoleColor)([\.]{1})([a-zA-Z]{3,})", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase) })
        {
        }

        protected override ColorTag TryCreateTagForMatch(Match match, int lineStart, int spanStart, string lineText)
        {
            if (lineText.Contains(match.Value) && match.Groups.Count == 4)
            {
                var value = match.Groups[3].Value;
                var precedingChar = match.Index > 0 ? lineText[match.Index - 1] : ' ';

                // Do this check here rather than as part of the RegEx so don't have to adjust the insertion point for the adornment
                if (new[] { ' ', ',', '(' }.Contains(precedingChar))
                {
                    if (ColorHelper.TryGetColor(value, out Color clr))
                    {
                        return new ColorTag(clr);
                    }else
                    {
                        System.Diagnostics.Debug.WriteLine($"Failed to understand '{value}' as a valid color.");
                    }
                }
            }

            return null;
        }
    }
}
