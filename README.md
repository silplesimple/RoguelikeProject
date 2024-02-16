# DunGeon Adventure

## 프로젝트 소개
플레이어가 몬스터를 물리치며 던전을 클리어하는 클래식 2D 로그라이크.

<br>

## 개발기간
* 24.02.08 ~ 24.01.16


### 멤버 구성
- 유시아(팀장) : **UI 관리,  캐릭터 조작,  퍼마데스 시스템, 피해와 체력 관리, 사운드**
- 심선규 : **랜덤 던전 생성, 보스 전투**
- 이건형 : **아이템 수집, 몬스터 생성 및 AI**
- 김관철 : **전투 시스템, 스킬**
  (팀노션)<https://www.notion.so/7-7-7-7fac2c85c86d44a39b630219e69ce406>

### 개발 환경
- `Unity 2022.3.2f`

## 주요 기능
#### 시작씬
- Start 버튼 (게임 시작)
- Exit 버튼 (게임 종료)
- 
#### 메인씬 - 일반 맵
- 캐릭터 상하좌우로 이동(w, a, s, d)
- 캐릭터 스킬 사용(space bar), 몬스터 넉백 효과
- 마우스 좌클릭 공격
- 플레이어 최초 체력 3회 설정, 이후 몬스터와 1번 충돌 마다 체력-1
- 체력 전부 감소 시 게임오버씬
- 맵에 랜덤하게 아이템 드랍, 플레이어와 아이템 충돌시 획득, 이후 체력+1
- 플레이어를 추적하며 따라오는 몬스터
- 일정 횟수 이상 몬스터를 공격하면 해당 맵 클리어, 이후 다른 맵으로 이동할 수 있는 루트 활성화
- 다음 맵으로 이동 시 루트 비활성화
- 
#### 메인씬 - 보스맵
- 보스몬스터 출현(기존 몬스터 체력의 약 2.5배)
- 기존 몬스터보다 더 빠르게 플레이어를 추적
- 체력 전부 감소 시 게임오버씬

#### 게임 클리어 씬
- Continue 버튼(시작씬으로 이동)
- Exit 버튼(게임 종료)
- 
#### 게임 오버 씬
- Mainmenu 버튼(시작씬으로 이동)
- Exit 버튼(게임 종료)

