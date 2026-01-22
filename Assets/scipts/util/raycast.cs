using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public static class RaycastUtilities
{

	public record RayData<T>(T key, Vector2 Origin, Vector2 Direction, float Distance, LayerMask Mask);

	public static RaycastHit2D CastRay<T>(RayData<T> rayData, bool drawRays = true) => CastAllRays(new RayData<T>[] { rayData }, drawRays).First().raycastHit;

	public static ReadOnlyCollection<(T rayDataKey, RaycastHit2D raycastHit)> CastAllRays<T>(IEnumerable<RayData<T>> rayDatas, bool drawRays = true)
	{
		if (drawRays)
		{
			DrawAllRays(rayDatas);
		}

		return rayDatas
				.Select(x => (x.key, Physics2D.Raycast(x.Origin, x.Direction, x.Distance, x.Mask)))
				.ToList()
				.AsReadOnly();
	}

	public static void DrayAllRays<T>(RayData<T> raycastData) => DrawAllRays(new[] { raycastData });
	public static void DrawAllRays<T>(IEnumerable<RayData<T>> rayDatas)
	{
		foreach (var raycast in rayDatas)
		{
			Debug.DrawRay(
					raycast.Origin,
					raycast.Direction * raycast.Distance,
					Color.cyan);
		}
	}
}

// HACK: Fix c# bug.
namespace System.Runtime.CompilerServices
{
	internal static class IsExternalInit { }
}