﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapSettings))]
public class BuildingMaker : InfrastructureBehaviour
{
    public Material building;

    private MapSettings set;

    void Awake(){
        set=this.gameObject.GetComponent<MapSettings>();
    }

    IEnumerator Start()
    {
        
        while (!map.IsReady)
        {
            yield return null;
        }

        foreach (var way in map.ways.FindAll((w) => { return w.IsBuilding && w.NodeIDs.Count > 1; }))
        {
            GameObject go = new GameObject();
            Vector3 localOrigin = GetCentre(way);
            Vector3 TransformPos=localOrigin - map.bounds.Centre;

            //magnitude horizontal 
            TransformPos.x*=set.mag_h; TransformPos.z*=set.mag_h;

            go.transform.position = TransformPos;

            MeshFilter mf = go.AddComponent<MeshFilter>();
            MeshRenderer mr = go.AddComponent<MeshRenderer>();

            mr.material = building;

            List<Vector3> vectors = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<int> indices = new List<int>();

            for (int i = 1; i < way.NodeIDs.Count; i++)
            {
                OSMnode p1 = map.nodes[way.NodeIDs[i - 1]];
                OSMnode p2 = map.nodes[way.NodeIDs[i]];

                Vector3 v1 = new Vector3(p1.Longitude,0,p1.Latitude) - localOrigin;
                Vector3 v2 = new Vector3(p2.Longitude,0,p2.Latitude) - localOrigin;

                //magnitude horizontal  
                v1.x*=set.mag_h; v1.z*=set.mag_h;
                v2.x*=set.mag_h; v2.z*=set.mag_h;

                Vector3 v3 = v1 + new Vector3(0, way.Height, 0);
                Vector3 v4 = v2 + new Vector3(0, way.Height, 0);

                //magnitude vertical 
                v3.y*=set.mag_v; 
                v4.y*=set.mag_v; 
                

                vectors.Add(v1);
                vectors.Add(v2);
                vectors.Add(v3);
                vectors.Add(v4);

                normals.Add(-Vector3.forward);
                normals.Add(-Vector3.forward);
                normals.Add(-Vector3.forward);
                normals.Add(-Vector3.forward);
                
                // index values
                int idx1, idx2,idx3, idx4;
                idx4 = vectors.Count - 1;
                idx3 = vectors.Count - 2;
                idx2 = vectors.Count - 3;
                idx1 = vectors.Count - 4;

                // first triangle v1, v3, v2
                indices.Add(idx1);
                indices.Add(idx3);
                indices.Add(idx2);

                // second triangle v3, v4, v2
                indices.Add(idx3);
                indices.Add(idx4);
                indices.Add(idx2);

                // third triangle v2, v3, v1
                indices.Add(idx2);
                indices.Add(idx3);
                indices.Add(idx1);

                // fourth triangle v2, v4, v3
                indices.Add(idx2);
                indices.Add(idx4);
                indices.Add(idx3);
            }

            mf.mesh.vertices = vectors.ToArray();
            mf.mesh.normals = normals.ToArray();
            mf.mesh.triangles = indices.ToArray();

            yield return null;
        }

    }
}
