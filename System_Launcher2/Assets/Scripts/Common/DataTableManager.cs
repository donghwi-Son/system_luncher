// �ý��� ���ӽ����̽� ���
using System;
// �ý��� �÷��� ���ӽ����̽� ���
using System.Collections.Generic;
// LINQ ���ӽ����̽� ���
using System.Linq;

// ������ ���̺��� �����ϴ� �̱��� Ŭ����
public class DataTableManager : SingletonBehaviour<DataTableManager>
{
    // ������ ������ ����� ��� ���
    private const string DATA_PATH = "DataTable";

    // �ʱ�ȭ �޼���
    protected override void Init()
    {
        // �θ� Ŭ������ Init ȣ��
        base.Init();

        // é�� ������ ���̺� �ε�
        LoadChapterDataTable();
        // ������ ������ ���̺� �ε�
        LoadItemDataTable();
    }

    // é�� ������ ���� ���� ����
    #region CHAPTER_DATA
    // é�� ������ ���̺� ���ϸ� ���
    private const string CHAPTER_DATA_TABLE = "ChapterDataTable";
    // é�� ������ ����Ʈ
    private List<ChapterData> ChapterDataTable = new List<ChapterData>();

    // é�� ������ ���̺� �ε� �޼���
    private void LoadChapterDataTable()
    {
        // CSV ������ �о �Ľ̵� ������ ��������
        var parsedDataTable = CSVReader.Read($"{DATA_PATH}/{CHAPTER_DATA_TABLE}");

        // �Ľ̵� ������ ��ȸ
        foreach (var data in parsedDataTable)
        {
            // é�� ������ ��ü ����
            var chapterData = new ChapterData
            {
                // é�� ��ȣ ����
                ChapterNo = Convert.ToInt32(data["chapter_no"]),
                // �� �������� �� ����
                TotalStage = Convert.ToInt32(data["total_stages"]),
                // é�� ���� �� ����
                ChapterRewardGem = Convert.ToInt32(data["chapter_reward_gem"]),
                // é�� ���� ��� ����
                ChapterRewardGold = Convert.ToInt32(data["chapter_reward_gold"]),
            };

            // é�� �����͸� ����Ʈ�� �߰�
            ChapterDataTable.Add(chapterData);
        }
    }

    // Ư�� é�� ��ȣ�� é�� ������ ��������
    public ChapterData GetChapterData(int chapterNo)
    {
        // LINQ�� ����Ͽ� �ش� é�� ��ȣ�� ������ ��ȯ
        return ChapterDataTable.Where(item => item.ChapterNo == chapterNo).FirstOrDefault();
    }
    // é�� ������ ���� ���� ��
    #endregion

    // ������ ������ ���� ���� ����
    #region ITEM_DATA
    // ������ ������ ���̺� ���ϸ� ���
    private const string ITEM_DATA_TABLE = "ItemDataTable";
    // ������ ������ ����Ʈ
    private List<ItemData> ItemDataTable = new List<ItemData>();

    // ������ ������ ���̺� �ε� �޼���
    private void LoadItemDataTable()
    {
        // CSV ������ �о �Ľ̵� ������ ��������
        var parsedDataTable = CSVReader.Read($"{DATA_PATH}/{ITEM_DATA_TABLE}");

        // �Ľ̵� ������ ��ȸ
        foreach (var data in parsedDataTable)
        {
            // ������ ������ ��ü ����
            var itemData = new ItemData
            {
                // ������ ID ����
                ItemId = Convert.ToInt32(data["item_id"]),
                // ������ �̸� ����
                ItemName = data["item_name"].ToString(),
                // ���ݷ� ����
                AttackPower = Convert.ToInt32(data["attack_power"]),
                // ���� ����
                Defense = Convert.ToInt32(data["defense"]),
            };

            // ������ �����͸� ����Ʈ�� �߰�
            ItemDataTable.Add(itemData);
        }
    }

    // Ư�� ������ ID�� ������ ������ ��������
    public ItemData GetItemData(int itemId)
    {
        // LINQ�� ����Ͽ� �ش� ������ ID�� ������ ��ȯ
        return ItemDataTable.Where(item => item.ItemId == itemId).FirstOrDefault();
    }
    // ������ ������ ���� ���� ��
    #endregion
}

// é�� ������ Ŭ����
public class ChapterData
{
    // é�� ��ȣ
    public int ChapterNo;
    // �� �������� ��
    public int TotalStage;
    // é�� ���� ��
    public int ChapterRewardGem;
    // é�� ���� ���
    public int ChapterRewardGold;
}

// ������ ������ Ŭ����
public class ItemData
{
    // ������ ID
    public int ItemId;
    // ������ �̸�
    public string ItemName;
    // ���ݷ�
    public int AttackPower;
    // ����
    public int Defense;
}

// ������ Ÿ�� ������
public enum ItemType
{
    // ����
    Weapon = 1,
    // ����
    Shield,
    // �䰩
    ChestArmor,
    // �尩
    Gloves,
    // ����
    Boots,
    // �Ǽ�����
    Accessory
}

// ������ ��� ������
public enum ItemGrade
{
    // �Ϲ�
    Common = 1,
    // ���
    Uncommon,
    // ���
    Rare,
    // ����
    Epic,
    // ����
    Legendary,
}
