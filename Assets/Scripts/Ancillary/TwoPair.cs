using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pair<T1, T2> {
    public T1 a;
    public T2 b;

    public Pair(T1 a, T2 b)
    {
        this.a = a;
        this.b = b;
    }

    public override bool Equals(object obj)
    {
        Pair<T1, T2> pair = obj as Pair<T1, T2>;
        return pair != null &&
               EqualityComparer<T1>.Default.Equals(a, pair.a) &&
               EqualityComparer<T2>.Default.Equals(b, pair.b);
    }

    public override int GetHashCode()
    {
        int hashCode = 2118541809;
        hashCode = hashCode * -1521134295 + EqualityComparer<T1>.Default.GetHashCode(a);
        hashCode = hashCode * -1521134295 + EqualityComparer<T2>.Default.GetHashCode(b);
        return hashCode;
    }

    public override string ToString()
    {
        return "(" + a.ToString() + " , " + b.ToString() + ")";
    }
}
