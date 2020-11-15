using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    public class Querys
        : IDocument
    {
        private readonly byte[] _hashName = new byte[]
        {
            109,
            100,
            53,
            72,
            97,
            115,
            104
        };
        private readonly byte[] _hash = new byte[]
        {
            84,
            113,
            79,
            53,
            88,
            73,
            50,
            70,
            56,
            86,
            49,
            68,
            49,
            81,
            73,
            78,
            108,
            86,
            86,
            115,
            81,
            65,
            61,
            61
        };
        private readonly byte[] _content = new byte[]
        {
            113,
            117,
            101,
            114,
            121,
            32,
            71,
            101,
            116,
            86,
            97,
            108,
            117,
            101,
            115,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            100,
            97,
            116,
            97,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            118,
            97,
            108,
            117,
            101,
            49,
            32,
            118,
            97,
            108,
            117,
            101,
            50,
            32,
            118,
            97,
            108,
            117,
            101,
            51,
            32,
            125,
            32,
            125
        };

        public ReadOnlySpan<byte> HashName => _hashName;

        public ReadOnlySpan<byte> Hash => _hash;

        public ReadOnlySpan<byte> Content => _content;

        public static Querys Default { get; } = new Querys();

        public override string ToString() => 
            @"query GetValues {
              data {
                value1
                value2
                value3
              }
            }";
    }
}
