using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevel
{
    void Submit(string answer);
}

//Ёто интерфейс Ч УконтрактФ, который говорит: Улюбой уровень об€зан уметь принимать SubmitФ