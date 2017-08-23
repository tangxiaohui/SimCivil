﻿using System;
using System.Collections.Generic;
using System.Text;
using SimCivil.Map;

namespace SimCivil.Store
{
    /// <summary>
    /// A map repository storing atlas in memory. Just designed for test.
    /// </summary>
    public class MemoryMapRepo : IMapRepository
    {
        protected Dictionary<(int X, int Y), Atlas> AtlasStore;

        public virtual bool Contains((int X, int Y) atlasIndex) => AtlasStore.ContainsKey(atlasIndex);

        public virtual Atlas GetAtlas((int X, int Y) atlasIndex) => AtlasStore[atlasIndex];

        public virtual void PutAtlas((int X, int Y) atlasIndex, Atlas atlas) => AtlasStore[atlasIndex] = atlas;

        public MemoryMapRepo()
        {
            AtlasStore = new Dictionary<(int X, int Y), Atlas>();
        }
    }
}
