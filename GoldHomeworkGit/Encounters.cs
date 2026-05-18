using Game.Characters;
using Game.Enums;
using Game.Nogari;
using Game.ShopSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Game.Encounters
{
    abstract class Encounter
    {
        
        public abstract void enc(Player player);
    }

    class EnemyEnc: Encounter
    {
        public override void enc(Player player)
        {
            Console.WriteLine("적과 조우했습니다."); //enc를 강제 구현해야 하잖아? 여기에서 이제 입력부도 받는 거지.
            Console.ReadLine();
        }
    }
    
    class AllyEnc: Encounter //이전의 인카운터를 기록해서 안 뜨게 하던가 해야하나
    {
        Random rand = new Random();
        public override void enc(Player player)
        {
            Console.WriteLine("아군과 조우했습니다.");

            int shopAppear = rand.Next(0, 101);

            if (shopAppear < 25)
            {
                Console.ReadKey();
                Console.WriteLine("후방에서 전진해오던 본대와 합류했습니다");
                Console.ReadKey();
                Console.WriteLine("( ㄷ_ㄷ) : 살아있었군. 정비할텐가?");
                Console.ReadKey();
                Shop shop = new Shop();
                shop.ShopOpen(player);                
            }
            else if(shopAppear < 50)
            {
                Console.ReadKey();
                Console.WriteLine("당신이 확인한 건 아군의 잔해였습니다.");
                Console.ReadKey();
                Console.WriteLine("쓸만한 걸 건지기로 합니다.");
                player.Fuel++;
                player.Cannon += 1;
                player.Gold += 30;

            }
            else if (shopAppear < 75)
            {
                Console.ReadKey();
                Console.WriteLine("당신은 아군 공병 대대와 조우했습니다.");
                Console.ReadKey();
                Console.WriteLine("자원을 지불하고 공격력을 업그레이드 받으시겠습니까? (가격 16, +2)");
                Console.WriteLine("1. 예, 그 외. 아니오.");

                string? input = Console.ReadLine();

                if (input == "1")
                {
                    if (player.Gold < 16)
                    {
                        Console.WriteLine("자원이 부족합니다.");
                    }
                    else
                    {
                        player.Gold = player.Gold - 16;
                        player.Atk = player.Atk + 2;
                        Console.WriteLine("공격력이 2만큼 증가했습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("다음을 기약하기로 합니다.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.ReadKey();
                Console.WriteLine("그들은 많이 지쳐보입니다. 직전의 전투에서 가까스로 살아돌아온 것 같습니다");
                Console.ReadKey();
                Console.WriteLine("그냥 지나가기로 결심합니다.");
            }
            Console.ReadLine();
        }
    }   
}
