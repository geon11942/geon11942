작업할 내용 리스트

굶지마(Don't Starve)

21. 인벤토리에서 우클릭한 아이템이 설치가능 기구일 경우 설치하는 기능 구현.
------------------------------------
22. 오브젝트끼리의 상호작용 구현. 바닥에 떨군 구울 수 음식아이템이 불 근처에 있을 경우 구워지는 기능. 
구워졌거나 불탈 수 있는 아이템이 불 근처에 있을 경우 내구도가 감소하다가 재로 변하는 기능 구현.
23. 상자 기구 구현. 우클릭 시 상자 전용 인터페이스가 열리고 그곳에 아이템을 드래그 할 경우 아이템이 옮겨져 보관 되는 기능
24. 요리 기구 구현. 기구 오브젝트를 우클릭 시 빈칸 4개가 있는 전용 인터페이스가 열리고 해당 칸에 재료 아이템을 드래그해 옮겨 4칸을 전부 채우면 요리 가능. 
요리는 넣은 재료 아이템 별로 정해진 재료 수치가 있고(육류나 채소), 그 수치에 맞는 레시피가 있을 경우 그 레시피에 우선 순위를 보고 우선 순위가 가장 높은 요리가 만들어짐
27. 시간제한이 있는 아이템 구현. 음식의 유통기한이나 도구의 사용기간 등 이미 정해진 기간이 흐르고 남은 기간에 따른 아이템의 상태 변경(음식은 회복량 감소, 도구는 공격력 감소)
------------------------------------
29. 현재 캐릭터가 있는 바닥에 따른 이동속도 변화 구현. 늪지대에선 느려지고 길에선 빨라지는 등의 속도 변화
30. 정신력이 낮아질때 생기는 이벤트 구현.(중요도 낮음. 나중으로 미뤄도 됨)
31. 오브젝트의 리젠 구현. 오브젝트가 재생이 가능한 오브젝트일 경우 시간이 지나면 다시 상호작용할 수 있게 되고 재생이 안되면 사라짐
32. 기본 맵 외에 추가로 동굴 맵 구현. 맵끼리 이동할 수 있는 오브젝트 추가
33. 
------------------------------------
34. 플레이어 캐릭터 외 개체 추가. 기본적인 AI로 생성된 위치 근처를 돌아다니는 AI, 도망치는 AI, 적대 개체를 쫓아가 공격하는 AI 등을 기본적으로 구현.

구현 완료 리스트
------------------------------------제작 시작 직후: 12월 4주차부터 하루이틀 정도------------------------------------
1.  마우스 왼쪽 버튼으로 누른 위치로 이동 둘다 사용
1. 플레이어 캐릭터 이동: wasd키로 상하좌우 이동,
2. 플레이어 캐릭터 데이터를 저장. 캐릭터 타입(인간, 거미, 어인), 최대 체력, 정신력, 공격력 배율은 공통 데이터, 캐릭터 별 데이터는 나중에 추가
3. 음식, 도구, 재료 등. 아이템의 공통 데이터 저장(아이템 ID,아이템 이름, 아이템 타입, 내구도 등)
4. 먹을 시 능력치 효과 등의 음식 데이터 구현. 유통기한은 기간만 저장해 두고 나중에 추가 구현.
5. 아이템 충돌 시 사용. 효과 적용(테스트)
6. 체력, 배고픔, 정신력 구현. 배고픔은 언제나 일정하게 감소, 체력은 배고픔이 0이거나 특정 상황마다 증감, 정신력은 특정 상황마다 증감
7. 체력, 배고픔, 정신력 UI로 표시. 증감에 따른 변경
8. 인벤토리 구현. 화면 하단에 UI로 표시.
9. 아이템 충돌 시 사용에서 근처에서 왼쪽 클릭시 획득으로 변경
10. 추가 - 스페이스바를 누르고 있으면 가까운 순서대로 근처의 오브젝트에 상호작용하거나 아이템 줍기.
11. 인벤토리 UI의 아이템에 마우스를 올리고 오른쪽 클릭하면 아이템을 사용(장비는 장착, 음식은 섭취)
12. 인벤토리 UI의 아이템에 마우스를 올리고 왼쪽 클릭하면 해당 아이템을 마우스로 들어 옮기는 기능.
------------------------------------일주일?정도의 기간
12. 마우스로 클릭해 들고 있는 아이템을 맵 바닥에 클릭하면 두고 캐릭터가 해당 위치로 이동하고 아이템을 떨구는 기능.
------------------------------------3일 정도
13. 그냥 클릭해 상호작용할 수 있는 오브젝트 구현. 음식을 구할 수 있는 덤불, 기초 재료를 주는 오브젝트 등
14. 도구 및 장비 아이템 구현. 공격력, 방어력, 사용회수와 사용기간 등을 구현. 사용되지 않는 데이터는 -1로 지정.
15. 도구 장착 구현. 도구 장착 후 클릭 시 전용 상호작용이 나오는 오브젝트 구현(도끼 들고 나무 클릭 시 장작 획등 등)
16. 밤낮 구현. 하루는 8분으로 시간 구분은 UI로 화면 색만 살짝 변하고(낮에는 평범하게, 밤에는 어두운 색) 실제 밝기와 광원의 상호작용은 나중에 추가
17. 4계절 및 온도 추가. 봄과 가을에는 온도가 괜찮지만 여름과 겨울에는 온도가 높아지거나 낮아져 체력이 지속적으로 감소. 
이를 막으려면 온도를 내리거나 높이는 장비를 착용하거나 오브젝트 근처에 머물러야함. 이를 위한 장비(횟불)와 오브젝트(얼음, 모닥불) 구현.
18. 계절외에도 온도가 변동하는 기능 추가. 모닥불에 붙어있으면 온도가 올라 체력이 감소되는 기능 구현.
19. 제작 기능 구현. 화면 왼쪽에 버튼을 추가하고 버튼을 누르면 조합 레시피 창이 나타나 재료를 준비하고 레시피를 누르면 아이템을 제작
20. 레시피 위에 마우스를 올리면 필요한 재료를 표시하는 기능 구현.
25. 맵 구현. 지형에 따른 바닥이나 지나갈 수 없는 바다 등의 지형 추가. 캐릭터가 이동할 때 바다를 향해 이동하면 벽에 부딪힌 것 처럼 진행 불가. 바다는 배를 만들어야 이동할 수 있음.
26. 오브젝트 랜덤 생성 기능 구현. 바다 위엔 바다 전용 오브젝트만 있고 지상 위엔 지상 전용 오브젝트만 있게 구현.
28. 밝기 구현과 밝기에 따른 상호작용 구현. 어두운 곳에 있을 경우 정신력이 지속적으로 감소하고 너무 오래 있으면 대미지를 입는 기능 구현.
