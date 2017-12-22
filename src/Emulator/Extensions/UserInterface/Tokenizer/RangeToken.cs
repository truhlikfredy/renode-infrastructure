//
// Copyright (c) 2010-2018 Antmicro
// Copyright (c) 2011-2015 Realtime Embedded
//
// This file is licensed under the MIT License.
// Full license text is available in 'licenses/MIT.txt'.
//
using System;
using Antmicro.Renode.Core;
using System.Linq;

namespace Antmicro.Renode.UserInterface.Tokenizer
{
    public abstract class RangeToken : Token
    {
        public override object GetObjectValue()
        {
            return Value;
        }

        public override string ToString()
        {
            return string.Format("[RangeToken: Value={0}]", Value);
        }

        public Range Value { get; protected set; }

        protected RangeToken(string value) : base(value)
        {
        }

        protected long[] ParseNumbers(string[] input)
        {
            var resultValues = new long[2];
            for(var i = 0; i < input.Length; ++i)
            {
                resultValues[i] = input[i].Contains('x')
                    ? Convert.ToInt64(input[i].Split('x')[1], 16)
                    : resultValues[i] = long.Parse(input[i]);

            }
            return resultValues;
        }
    }
}
