﻿using CYQ.Data.Cache;



namespace CYQ.Data.Lock
{
    internal class MemCacheLock : DistributedLock
    {
        private static readonly MemCacheLock _instance = new MemCacheLock();
        private MemCacheLock() { }
        public static MemCacheLock Instance
        {
            get
            {
                return _instance;
            }
        }
        public override LockType LockType
        {
            get
            {
                return LockType.MemCache;
            }
        }

        public override bool Lock(string key, int millisecondsTimeout)
        {
            return DistributedCache.MemCache.Lock(key, millisecondsTimeout);
        }

        public override void UnLock(string key)
        {
            DistributedCache.MemCache.UnLock(key);
        }
    }
}
