# Sparta_Up

## 주요 기능 구현
### 1. 플레이어 이동
  Input System을 이용한 키 매핑을 통해 입력 값을 받음
  
  ![image](https://github.com/user-attachments/assets/883b97c2-7eb8-4063-a897-519710eea494)
### 2. 상태 UI바 구현

![image](https://github.com/user-attachments/assets/72e35895-e008-40ea-9c8a-4a7ec652192e)

체력이 최태치가 아니면 배코픔을 소모해 체력회복
배고픔은 음식 섭취를 통해서 회복 가능
스테미나는 점프시 소모. 자연적으로 회복

![image](https://github.com/user-attachments/assets/324ac5a3-debd-45f3-8df6-519c279de935)

스킬 사용시 지속시간 UI표시

### 3. 동적 환경 조사

![image](https://github.com/user-attachments/assets/9226f81c-3cda-415f-8175-f17dd9e6bbe8)
![image](https://github.com/user-attachments/assets/48d50460-96e4-416c-ada1-4f4001f20235)

Raycast를 통해 바라보는 방향의 오브젝트 정보 표시
공격이 적중시 크로스헤어에 표시

### 4. 점프대
PlayerController를 가진 오브젝트와 충돌시 점프

### 5. 아이템
#### 아이템정보
아이템 정보를 ScriptableObject로 관리
#### 아이템 사용
소모품은 사용시 배고픔 증가(현재는 음식만 존재)

무기를 장착시 공격가능

방어구를 장착시 능력치 증가(현재는 점프만 증가)

스킬사용시 일시적으로 능력치 증가(현재는 속도만 증가)

## 트러블 슈팅
아이템을 먹으면 아이템 슬롯의 이미지를 할당하는데, 이 부분에서 NUllReference 오류가 발생했다.
해당 아이템의 이미지가 잘 들어갔는데도 불구하고, 계속 오류가 발생했다.
이유는 빈 슬롯을 찾는 과정에서 조건문이 잘못되어, 다음 아이템 슬롯에도 이미지를 할당하려 해서 오류가 발생했다.

## 개선 사항
아이템의 종류를 열거형으로 관리했는데, 
아이템의 종류가 더 다양해지고, 장비의 하위로 무기,방어구 등으로 관리 하려면 인터페이스로 관리 하는 것을 고려해 볼 필요가 있을 것 같다.

## 시연영상
https://youtu.be/fvlRzOce2A8
