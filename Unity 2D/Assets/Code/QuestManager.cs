﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{   
    public int questId;
    public int questActionIndex;// 퀘스트 대화 순서 변수
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData(){
        questList.Add(10, new QuestData("마을사람들과 대화하기", new int[] {1000, 2000}));

        questList.Add(20, new QuestData("루도의 동전 찾아주기.", new int[] {5000, 2000}));

        questList.Add(30, new QuestData("퀘스트 올 클리어!", new int[] {0}));
    }


    public int GetQuestTalkIndex(int id){ //npc id를 받고 퀘스트 번호 반환하는 함수
        return questId + questActionIndex;
    }

    public string CheckeQuest(int id)
    {
        if(id == questList[questId].npcId[questActionIndex])
        questActionIndex++;

        //퀘스트 오브젝트 컨트롤
        ControlObject();

        if(questActionIndex == questList[questId].npcId.Length){ //퀘스트 대화순서가 끝일때 퀘스트 번호 증가
             NextQueset();
        }

        return questList[questId].questName; //퀘스트 이름 반환
    }

    public string CheckeQuest()
    {
        return questList[questId].questName; //퀘스트 이름 반환
    }




    void NextQueset(){
        questId +=10;
        questActionIndex = 0;
    }

    void ControlObject(){
        switch(questId){
            case 10 :
                if(questActionIndex == 2)//대화 다 끝나면 동전 보이게
                    questObject[0].SetActive(true);
                break;
            case 20 :
                if(questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }

}
