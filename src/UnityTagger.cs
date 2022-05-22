﻿using Microsoft.VisualStudio.Text;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace CsInlineColorViz
{
    internal sealed class UnityTagger : RegexTagger<ColorTag>
    {
        internal UnityTagger(ITextBuffer buffer)
            : base(buffer, new[] { new Regex("(<Color=#)([0-9A-F]{3,8})(>)", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase) })
        {
        }

        protected override ColorTag TryCreateTagForMatch(Match match, int lineStart, int spanStart, string lineText)
        {
            if (lineText.Contains(match.Value) && match.Groups.Count == 4)
            {
                var value = match.Groups[2].Value;

                if (ColorHelper.TryGetHexColor($"#{value}", out Color clr))
                {
                    return new ColorTag(clr);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to understand '{value}' as a valid color.");
                }
            }

            return null;
        }
    }
}
