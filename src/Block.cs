﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ipfs.Http
{
    /// <inheritdoc />
    [DataContract]
    public class Block : IDataBlock
    {
        long? size;

        /// <inheritdoc />
        [DataMember]
        public Cid Id { get; set; }

        /// <inheritdoc />
        [DataMember]
        public byte[] DataBytes { get; set; }

        /// <inheritdoc />
        public Stream DataStream
        {
            get
            {
                return new MemoryStream(DataBytes, false);
            }
        }

        /// <inheritdoc />
        [DataMember]
        public long Size
        {
            get
            {
                if (size.HasValue)
                {
                    return size.Value;
                }
                return DataBytes.Length;
            }
            set
            {
                size = value;
            }
        }
        
    }

}
