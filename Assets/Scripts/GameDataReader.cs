﻿using System.IO;
using UnityEngine;

public class GameDataReader : MonoBehaviour
{
    public int Version { get; }
    BinaryReader reader;

    public GameDataReader Init(BinaryReader reader) {
        this.reader = reader;
        return this;
    }

    public GameDataReader(BinaryReader reader, int Version) {
        this.reader = reader;
        this.Version = Version;
    }

    public float ReadFloat () {
		return reader.ReadSingle();
	}

	public int ReadInt () {
		return reader.ReadInt32();
	}

    public Quaternion ReadQuaternion () {
		Quaternion value;
		value.x = reader.ReadSingle();
		value.y = reader.ReadSingle();
		value.z = reader.ReadSingle();
		value.w = reader.ReadSingle();
		return value;
	}

	public Vector3 ReadVector3 () {
		Vector3 value;
		value.x = reader.ReadSingle();
		value.y = reader.ReadSingle();
		value.z = reader.ReadSingle();
		return value;
	}

    public Color ReadColor() {
        Color value;
        value.r = reader.ReadSingle();
        value.g = reader.ReadSingle();
        value.b = reader.ReadSingle();
        value.a = reader.ReadSingle();
        return value;
    }

    public ShapeInstance ReadShapeInstance() {
        return new ShapeInstance(reader.ReadInt32());
    }

    public Random.State ReadRandomState() {
        return JsonUtility.FromJson<Random.State>(reader.ReadString());
    }
}
