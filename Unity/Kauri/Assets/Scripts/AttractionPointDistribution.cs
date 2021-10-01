﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionPointDistribution
{
    public List<Vector3> GenerateAttractorsSpherical(int n, float r, Vector3 start)
    {
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < n; i++)
        {
            float radius = Random.Range(0f, 1f);
            radius = Mathf.Pow(Mathf.Sin(radius * Mathf.PI / 2f), 0.8f);
            radius *= r;
            // 2 angles are generated from which a direction will be computed
            float alpha = Random.Range(0f, Mathf.PI);
            float theta = Random.Range(0f, Mathf.PI * 2f);

            Vector3 pt = new Vector3(
                radius * Mathf.Cos(theta) * Mathf.Sin(alpha),
                radius * Mathf.Sin(theta) * Mathf.Sin(alpha),
                radius * Mathf.Cos(alpha)
            );

            // translation to match the parent position
            pt += start - new Vector3(0, r, 0);

            points.Add(pt);
        }
        return points;
    }
    public List<Vector3> GenerateAttractorsHemisphere(int n, float r, Vector3 start)
    {
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < n; i++)
        {
            float radius = Random.Range(0f, 1f);
            radius = Mathf.Pow(Mathf.Sin(radius * Mathf.PI / 2f), 0.8f);
            radius *= r;
            // 2 angles are generated from which a direction will be computed
            float alpha = Random.Range(0f, Mathf.PI);
            float theta = Random.Range(0f, Mathf.PI);

            Vector3 pt = new Vector3(
                radius * Mathf.Cos(theta) * Mathf.Sin(alpha),
                radius * Mathf.Sin(theta) * Mathf.Sin(alpha),
                radius * Mathf.Cos(alpha)
            );

            // translation to match the parent position
            pt += start + new Vector3(0, r, 0);

            points.Add(pt);
        }
        return points;
    }

    public List<Vector3> GenerateAttractorsMatureBranches(int n, float r, Vector3 start)
    {
        Vector3 center = start + new Vector3(0, r, 0);
        List<Vector3> points = new List<Vector3>();
        while(points.Count<n)
        {
            float radius = Random.Range(0f, 1f);
            radius = Mathf.Pow(Mathf.Sin(radius * Mathf.PI / 2f), 0.8f);
            radius *= r;
            // 2 angles are generated from which a direction will be computed
            float alpha = Random.Range(0f, Mathf.PI);
            float theta = Random.Range(0f, Mathf.PI * 2f);

            Vector3 pt = new Vector3(
                radius * Mathf.Cos(theta) * Mathf.Sin(alpha),
                radius * Mathf.Sin(theta) * Mathf.Sin(alpha),
                radius * Mathf.Cos(alpha)
            );

            if (pt.y < -r/3)
            {
                continue;
            }
            else if(pt.y < 0)
            {
                Vector2 pt2D = new Vector2(pt.x, pt.z);
                Vector2 center2D = new Vector2(start.x, start.z);
                if (Vector2.Distance(pt2D, center2D) < 2)
                {
                    continue;
                }
            }

            // translation to match the parent position
            pt += center;

            points.Add(pt);
        }
        return points;
    }

    public List<Vector3> GenerateAttractorsCube(int n, float r, Vector3 start)
    {
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < n; i++)
        {
            float x = Random.Range(-r, r);
            float y = Random.Range(-r, r);
            float z = Random.Range(-r, r);
            Vector3 point = start + new Vector3(x, y, z) + new Vector3(0, -r, 0);
            points.Add(point);
        }
        return points;
    }
}
