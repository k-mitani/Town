using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class StockManager : MonoBehaviour
{
    [SerializeField] private int wood;
    [SerializeField] private int stone;
    [SerializeField] private int fish;

    private int maxAmount;
    private int TotalAmount
    {
        get
        {
            var total = 0;
            foreach (var amount in _dictResource.Values)
            {
                total = amount;
            }
            return total;
        }
    }

    private Dictionary<Resource, int> _dictResource = new Dictionary<Resource, int>();

    public StockManager()
    {
        foreach (var res in Util.GetEnumArray<Resource>())
        {
            _dictResource.Add(res, 0);
        }
    }

    public void Add(Resource res, int amount)
    {
        var currentTotal = TotalAmount;
        var remainingCapacity = maxAmount - currentTotal;
        amount = math.min(amount, remainingCapacity);
        _dictResource[res] += amount;
        Debug.Log($"Add {res}:{amount} -> {_dictResource[res]}");
    }

    public void Consume(Resource res, int amount)
    {
        var currentAmount = _dictResource[res];
        if (currentAmount < amount) 
        {
            throw new System.ArgumentException($"Consume 資源不足 ({res}:{currentAmount},{amount})", nameof(amount));
        }

        currentAmount -= amount;
        _dictResource[res] = currentAmount;
        Debug.Log($"Consume {res}:{amount} -> {currentAmount}");
    }

    public List<(Resource, int)> GetAmountList()
    {
        return _dictResource
            .Select(kv => (kv.Key, kv.Value))
            .ToList();
    }
}


public enum Resource
{
    /// <summary>木材</summary>
    Wood,
    /// <summary>合板</summary>
    Planks,
    /// <summary>石材</summary>
    Stone,
    /// <summary>石炭</summary>
    Charcoal,
    /// <summary>鉄鉱石</summary>
    IronOre,
    /// <summary>金鉱石</summary>
    GoldOre,
    /// <summary>鉄</summary>
    Iron,
    /// <summary>金</summary>
    Gold,
    /// <summary>工具</summary>
    Tools,
    /// <summary>水</summary>
    Water,
    /// <summary>魚</summary>
    Fish,
    /// <summary>パン</summary>
    Bread,
    /// <summary>肉</summary>
    Meat,
    /// <summary>小麦</summary>
    Wheat,
    /// <summary>小麦粉</summary>
    Flour,
    /// <summary>豚肉</summary>
    Pigs,
    /// <summary>ハーブ</summary>
    Herbs,
    /// <summary>羊毛</summary>
    Wool,
    /// <summary>毛織物</summary>
    Fabrics,
    /// <summary>服</summary>
    Clothes,
    /// <summary>宝飾品</summary>
    Jewelry,
    /// <summary>グレープ</summary>
    Grapes,
    /// <summary>グレープジュース</summary>
    GrapeJuice,
    /// <summary>ホップ</summary>
    Hops,
    /// <summary>ビール</summary>
    Brew,
    /// <summary>ソーセージ</summary>
    Sausages,
    /// <summary>皮</summary>
    Skins,
    /// <summary>革</summary>
    Leather,
    /// <summary>武器</summary>
    Weapons,
    /// <summary>防具</summary>
    Armors,
}
