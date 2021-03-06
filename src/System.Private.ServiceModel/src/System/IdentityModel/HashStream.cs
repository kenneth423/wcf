// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using System.Security.Cryptography;
using System.ServiceModel;

namespace System.IdentityModel
{
    internal sealed class HashStream : Stream
    {
        private bool _disposed;

        private MemoryStream _logStream;

#pragma warning disable CS0436 // HashAlgorithm conflicts with imported types 
        /// <summary>
        /// Constructor for HashStream. The HashAlgorithm instance is owned by the caller.
        /// </summary>
        public HashStream(HashAlgorithm hash)
        {
            if (hash == null)
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("hash");

            Reset(hash);
        }
#pragma warning restore CS0436

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override long Length
        {
            get { return 0L; }
        }

        public override long Position
        {
            get { return 0L; }
            set
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
            }
        }

        public override void Flush()
        {
        }

        public void FlushHash()
        {
            FlushHash(null);
        }

        public void FlushHash(MemoryStream preCanonicalBytes)
        {
            throw ExceptionHelper.PlatformNotSupported();
        }

        public byte[] FlushHashAndGetValue()
        {
            return FlushHashAndGetValue(null);
        }

        public byte[] FlushHashAndGetValue(MemoryStream preCanonicalBytes)
        {
            throw ExceptionHelper.PlatformNotSupported();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        }

        public void Reset()
        {
            throw ExceptionHelper.PlatformNotSupported();
        }

#pragma warning disable CS0436 // HashAlgorithm conflicts with imported types 
        public void Reset(HashAlgorithm hash)
        {
            throw ExceptionHelper.PlatformNotSupported();
        }
#pragma warning restore CS0436

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw ExceptionHelper.PlatformNotSupported();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        }

        public override void SetLength(long length)
        {
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                //
                // Free all of our managed resources
                //

                if (_logStream != null)
                {
                    _logStream.Dispose();
                    _logStream = null;
                }
            }

            // Free native resources, if any.

            _disposed = true;
        }
    }
}
