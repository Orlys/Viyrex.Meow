﻿namespace Viyrex.Meow.Html.Elements
{
    public sealed class Del : ElementBase
    {
        public override ElementType ElementType => ElementType.Normal;

        public string Cite { get; set; }

        public string DateTime { get; set; }
    }
}
