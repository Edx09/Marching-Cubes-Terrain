﻿using Unity.Mathematics;

namespace Eldemarkki.VoxelTerrain.World.Chunks
{
    /// <summary>
    /// A container for all of the chunks in the world
    /// </summary>
    public class ChunkStore : PerChunkStore<ChunkProperties>
    {
        /// <summary>
        /// If data does not already exist at <paramref name="chunkCoordinate"/>, it generates the data for a chunk at coordinate <paramref name="chunkCoordinate"/>, and adds it to the chunks dictionary in <see cref="PerChunkStore{T}"/>
        /// </summary>
        /// <param name="chunkCoordinate">The coordinate to generate the data for</param>
        public override void GenerateDataForChunk(int3 chunkCoordinate)
        {
            if (!DoesChunkExistAtCoordinate(chunkCoordinate))
            {
                ChunkProperties chunkProperties = new ChunkProperties();
                chunkProperties.Initialize(chunkCoordinate, VoxelWorld.WorldSettings.ChunkSize);
                AddChunk(chunkCoordinate, chunkProperties);
            }
        }

        /// <summary>
        /// If data does not already exist at <paramref name="chunkCoordinate"/>, it generates the data for a chunk at coordinate <paramref name="chunkCoordinate"/>, and adds it to the chunks dictionary in <see cref="PerChunkStore{T}"/>. The new data is generated to <paramref name="existingData"/>.
        /// </summary>
        /// <param name="chunkCoordinate">The coordinate to generate the data for</param>
        /// <param name="existingData">The already existing data that will be used to generate the data into</param>
        public override void GenerateDataForChunk(int3 chunkCoordinate, ChunkProperties existingData)
        {
            if (!DoesChunkExistAtCoordinate(chunkCoordinate))
            {
                existingData.MeshCollider.enabled = false;
                existingData.MeshRenderer.enabled = false;
                existingData.Initialize(chunkCoordinate, VoxelWorld.WorldSettings.ChunkSize);
                AddChunk(chunkCoordinate, existingData);
            }
        }
    }
}