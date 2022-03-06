using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pair<T> {
	public T a, b;

    public Pair(T a, T b)
    {
        this.a = a;
        this.b = b;
    }
    public override bool Equals(object obj)
    {
        Pair<T> pair = obj as Pair<T>;
        return pair != null &&
               EqualityComparer<T>.Default.Equals(a, pair.a) &&
               EqualityComparer<T>.Default.Equals(b, pair.b);
    }

    public override int GetHashCode()
    {
        int hashCode = 2118541809;
        hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(a);
        hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(b);
        return hashCode;
    }
    public override string ToString()
    {
        return "(" + a.ToString() + " , " + b.ToString() + ")";
    }
}
