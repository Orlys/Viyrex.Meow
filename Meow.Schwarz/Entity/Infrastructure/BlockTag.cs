﻿namespace Meow.Schwarz.Entity.Infrastructure
{
    using Interface;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class BlockTag : AttributeTagSegment, IBlockTag
    {
        internal BlockTag(StartTag startTag, EndTag endTag, IEnumerable<ISegment> children)
            : base(((IPosition)startTag).Start, ((IPosition)endTag).Stop, startTag.Source, startTag.TagName, startTag.Attributes)
        {
            if (((IPosition)startTag).Start > ((IPosition)endTag).Stop)
                throw new Exception($"Tag '{startTag.TagName}' and '{endTag.TagName}' aren't matched !");

            this.StartTag = startTag;
            this.EndTag = endTag;
            this.Children = children?.ToList() ?? new List<ISegment>();
        }

        public override string Block => this.StartTag.Block + this.Content + this.EndTag.Block;

        public IList<ISegment> Children { get; }

        public string Content => string.Join(null, this.Children.Select(x => x.Block));

        public EndTag EndTag { get; }

        public StartTag StartTag { get; }

        public IEnumerator<ISegment> GetEnumerator()
        {
            return this.Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public override string TextLayout() => this.StartTag.TextLayout() + this.Content + this.EndTag.Block;
    }
}