﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


public static class StopwatchExtension
{
    private static readonly ConcurrentDictionary<ScoreRange, ConsoleColor> _colorCache;
    static StopwatchExtension()
    {
        _colorCache = new ConcurrentDictionary<ScoreRange, ConsoleColor>();
        _colorCache[new ScoreRange(0, 20)] = ConsoleColor.Green;
        _colorCache[new ScoreRange(20, 100)] = ConsoleColor.Cyan;
        _colorCache[new ScoreRange(100, 500)] = ConsoleColor.Yellow;
        _colorCache[new ScoreRange(500, 1000)] = ConsoleColor.Magenta;
        _colorCache[new ScoreRange(1000, 100000)] = ConsoleColor.Red;
    }
    public static void StopAndShowCategoreInfo(this Stopwatch stopwatch, string nodeName, string info, int level)
    {
        stopwatch.Stop();
        var color = Console.ForegroundColor;
        foreach (var item in _colorCache)
        {
            if (item.Key.IsInRange(stopwatch.ElapsedMilliseconds))
            {
                Console.ForegroundColor = item.Value;
                for (int i = 0; i < level; i += 1)
                {
                    Console.Write("\t");
                }
                Console.WriteLine($"---{nodeName}\t{info} : {stopwatch.ElapsedMilliseconds}ms");
            }
        }
        Console.ForegroundColor = color;
    }

    /// <summary>
    /// 设置颜色等级
    /// </summary>
    /// <param name="stopwatch"></param>
    /// <param name="scoreRange"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Stopwatch SetLevel(this Stopwatch stopwatch, ScoreRange scoreRange, ConsoleColor color)
    {
        _colorCache[scoreRange] = color;
        return stopwatch;
    }
}

/// <summary>
/// 分数模型
/// </summary>
public class ScoreRange
{
    private readonly long _min;
    private readonly long _max;

    public ScoreRange(long min, long max)
    {
        _min = min;
        _max = max;
    }
    /// <summary>
    /// 判断得分是否在范围内
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    public bool IsInRange(long score)
    {
        return _min <= score && score <= _max;
    }
}

