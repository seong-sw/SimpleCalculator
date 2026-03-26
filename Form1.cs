namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // 새롭게 진행하는 연산인지 확인
        bool isClear = true;
        // 연산 결과 저장
        double result = 0;
        // 마지막으로 사용된 피연산자 (반복된 '=' 연산에 사용)
        double lastOperand = 0;
        // 마지막으로 사용된 연산자 (반복된 '=' 연산에 사용)
        short lastOp = 0;
        // 전체 식 표시용 문자열
        string expression = "";
        // 내부 평가용 원시 식 (숫자와 기호, 공백으로 토큰 구분)
        string exprRaw = "";
        // 현재 연산자 저장 (0 ~ 4)
        short op = 0;

        public Form1()
        {
            InitializeComponent();
            txtResult.Text = "0";
        }



        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (isClear)
            {
                txtResult.Text = btn.Text;
                if (txtResult.Text != "0")
                {
                    isClear = false;
                }
                // 전체 식에 현재 입력 반영 (expression이 비어있지 않으면 공백 추가)
                txtCalculate.Text = string.IsNullOrEmpty(expression) ? FormatForExpression(txtResult.Text) : expression + " " + FormatForExpression(txtResult.Text);
            }
            else
            {
                txtResult.Text += btn.Text;
                // 전체 식에 현재 입력 반영 (expression이 비어있지 않으면 공백 추가)
                txtCalculate.Text = string.IsNullOrEmpty(expression) ? FormatForExpression(txtResult.Text) : expression + " " + FormatForExpression(txtResult.Text);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 만약 현재 입력이 있으면 원시 식에 추가
            if (!isClear)
            {
                exprRaw = string.IsNullOrEmpty(exprRaw) ? txtResult.Text : exprRaw + " " + txtResult.Text;
                expression = string.IsNullOrEmpty(expression) ? FormatForExpression(txtResult.Text) : expression + " " + FormatForExpression(txtResult.Text);
            }

            if (!string.IsNullOrEmpty(exprRaw))
            {
                var toks = exprRaw.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                double? eval = EvaluateTokens(toks);
                if (eval.HasValue)
                {
                    result = eval.Value;
                    txtResult.Text = result.ToString();
                    txtCalculate.Text = BuildExpressionFromTokens(toks) + " = " + FormatForExpression(result.ToString());
                }
                // 초기화
                exprRaw = "";
                expression = "";
                isClear = true;
            }
        }

        // 주어진 피연산자를 사용해 현재 결과에 연산 적용
        private void ApplyOperation(short operation, double num)
        {
            switch (operation)
            {
                case 1: // +
                    result += num;
                    break;
                case 2: // -
                    result -= num;
                    break;
                case 3: // *
                    result *= num;
                    break;
                case 4: // /
                    if (num == 0)
                    {
                        // 간단한 0으로 나누기 처리
                        txtCalculate.Text = FormatForExpression(expression) + (string.IsNullOrEmpty(expression) ? "" : " ") + FormatForExpression(txtResult.Text) + " / 0 =";
                        txtResult.Text = "Cannot divide by zero";
                        result = 0;
                        op = 0;
                        lastOp = 0;
                        isClear = true;
                        return;
                    }
                    result /= num;
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HandleOperator(1);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            HandleOperator(2);
        }

        private void btnMuliply_Click(object sender, EventArgs e)
        {
            HandleOperator(3);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            HandleOperator(4);
        }

        // + - * / 연산자 동작을 통일하는 일반 핸들러
        private void HandleOperator(short newOp)
        {
            // 연산자 누르면 현재 입력(있다면)을 원시 식에 추가 후 연산자 추가
            if (!isClear)
            {
                exprRaw = string.IsNullOrEmpty(exprRaw) ? txtResult.Text : exprRaw + " " + txtResult.Text;
            }
            exprRaw = string.IsNullOrEmpty(exprRaw) ? OpToString(newOp) : exprRaw + " " + OpToString(newOp);
            expression = BuildExpressionFromTokens(exprRaw.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList());

            // 준비
            if (double.TryParse(txtResult.Text, out double tmp)) result = tmp;
            txtResult.Text = result.ToString();
            isClear = true;
            op = newOp;
            lastOp = 0;
            txtCalculate.Text = expression;
        }

        private void btnOpenParen_Click(object sender, EventArgs e)
        {
            // 여는 괄호는 바로 원시 식에 추가
            exprRaw = string.IsNullOrEmpty(exprRaw) ? "(" : exprRaw + " (";
            expression = BuildExpressionFromTokens(exprRaw.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList());
            txtCalculate.Text = expression;
            // 다음 숫자 입력을 기대
            isClear = true;
        }

        private void btnCloseParen_Click(object sender, EventArgs e)
        {
            // 현재 입력이 있으면 추가
            if (!isClear)
            {
                exprRaw = string.IsNullOrEmpty(exprRaw) ? txtResult.Text + " )" : exprRaw + " " + txtResult.Text + " )";
            }
            else
            {
                exprRaw = string.IsNullOrEmpty(exprRaw) ? ")" : exprRaw + " )";
            }
            expression = BuildExpressionFromTokens(exprRaw.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList());
            txtCalculate.Text = expression;
            // 간단히 현재 결과로 표시
            isClear = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (isClear)
            {
                txtResult.Text = "0.";
                isClear = false;
                // 전체 식에 현재 입력 반영 (expression이 비어있지 않으면 공백 추가)
                txtCalculate.Text = string.IsNullOrEmpty(expression) ? FormatForExpression(txtResult.Text) : expression + " " + FormatForExpression(txtResult.Text);
                return;
            }

            if (!txtResult.Text.Contains('.'))
            {
                txtResult.Text += ".";
                txtCalculate.Text = string.IsNullOrEmpty(expression) ? FormatForExpression(txtResult.Text) : expression + " " + FormatForExpression(txtResult.Text);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 모든 상태 초기화
            txtResult.Text = "0";
            isClear = true;
            result = 0;
            op = 0;
            lastOp = 0;
            lastOperand = 0;
            expression = "";
            txtCalculate.Text = "";
        }

        // 전체 초기화
        private void btnC_Click(object sender, EventArgs e)
        {
            // 전체 초기화는 기존 Clear와 동일하게 동작
            btnClear_Click(sender, e);
        }

        // 현재 입력값만 지우기 (식은 유지)
        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            isClear = true;
            // 표시되는 전체 식에서는 현재 입력을 제거
            txtCalculate.Text = expression;
        }

        // 현재 입력의 마지막 문자 삭제
        private void btnDel_Click(object sender, EventArgs e)
        {
            // 에러 메시지 상태에서는 전체 입력 초기화
            if (txtResult.Text == "Cannot divide by zero")
            {
                txtResult.Text = "0";
                isClear = true;
                txtCalculate.Text = expression;
                return;
            }

            if (isClear)
            {
                // 새로 시작된 상태에서는 삭제할 게 없음
                txtResult.Text = "0";
                txtCalculate.Text = expression;
                return;
            }

            if (txtResult.Text.Length > 1)
            {
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
            }
            else
            {
                txtResult.Text = "0";
                isClear = true;
            }

            // 전체 식 표시 갱신 (expression과 현재 입력 사이 공백 처리)
            txtCalculate.Text = isClear ? expression : (string.IsNullOrEmpty(expression) ? FormatForExpression(txtResult.Text) : expression + " " + FormatForExpression(txtResult.Text));
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // 현재 피연산자의 부호를 바꿈
            if (!isClear && txtResult.Text != "Cannot divide by zero")
            {
                if (double.TryParse(txtResult.Text, out double num))
                {
                    num = -num;
                    txtResult.Text = num.ToString();
                    // 전체 식 표시 업데이트 (expression이 비어있지 않으면 공백 추가)
                    txtCalculate.Text = string.IsNullOrEmpty(expression) ? FormatForExpression(txtResult.Text) : expression + " " + FormatForExpression(txtResult.Text);
                }
            }
        }

        // 음수는 괄호로 감싸서 표시
        private string FormatForExpression(string s)
        {
            if (double.TryParse(s, out double v))
            {
                if (v < 0)
                {
                    return "(" + v.ToString() + ")";
                }
                return v.ToString();
            }
            return s;
        }

        // 연산자 코드를 기호 문자열로 변환
        private string OpToString(short operation)
        {
            return operation switch
            {
                1 => "+",
                2 => "-",
                3 => "×",
                4 => "÷",
                _ => "",
            };
        }

        // 토큰 리스트로부터 표시용 문자열 생성 (숫자는 FormatForExpression 사용)
        private string BuildExpressionFromTokens(List<string> toks)
        {
            if (toks == null || toks.Count == 0) return string.Empty;
            var parts = new List<string>();
            foreach (var t in toks)
            {
                if (t == "+" || t == "-" || t == "×" || t == "÷" || t == "(" || t == ")")
                {
                    parts.Add(t);
                }
                else
                {
                    parts.Add(FormatForExpression(t));
                }
            }
            return string.Join(" ", parts);
        }

        // 토큰(중위표기) 리스트를 평가하여 결과 반환. 괄호와 우선순위 지원.
        private double? EvaluateTokens(List<string> toks)
        {
            if (toks == null || toks.Count == 0) return null;

            // 셔팅야드로 RPN 변환
            var rpn = TokensToRpn(toks);
            if (rpn == null) return null;

            // RPN 평가
            var stack = new Stack<double>();
            foreach (var tk in rpn)
            {
                if (double.TryParse(tk, out double val))
                {
                    stack.Push(val);
                }
                else if (tk == "+" || tk == "-" || tk == "×" || tk == "÷")
                {
                    if (stack.Count < 2) return null;
                    double b = stack.Pop();
                    double a = stack.Pop();
                    double res = 0;
                    switch (tk)
                    {
                        case "+": res = a + b; break;
                        case "-": res = a - b; break;
                        case "×": res = a * b; break;
                        case "÷":
                            if (b == 0)
                            {
                                txtCalculate.Text = BuildExpressionFromTokens(toks) + " / 0 =";
                                txtResult.Text = "Cannot divide by zero";
                                return null;
                            }
                            res = a / b;
                            break;
                    }
                    stack.Push(res);
                }
                else
                {
                    // 알 수 없는 토큰
                    return null;
                }
            }

            if (stack.Count != 1) return null;
            return stack.Pop();
        }

        // 셔팅야드 알고리즘: 중위표기 토큰을 RPN으로 변환
        private List<string>? TokensToRpn(List<string> toks)
        {
            var output = new List<string>();
            var ops = new Stack<string>();

            foreach (var t in toks)
            {
                if (double.TryParse(t, out _))
                {
                    output.Add(t);
                }
                else if (t == "+" || t == "-" || t == "×" || t == "÷")
                {
                    while (ops.Count > 0)
                    {
                        var top = ops.Peek();
                        if (top == "(") break;
                        int precTop = GetPrecedence(top);
                        int precT = GetPrecedence(t);
                        if (precTop > precT || (precTop == precT))
                        {
                            output.Add(ops.Pop());
                            continue;
                        }
                        break;
                    }
                    ops.Push(t);
                }
                else if (t == "(")
                {
                    ops.Push(t);
                }
                else if (t == ")")
                {
                    bool found = false;
                    while (ops.Count > 0)
                    {
                        var top = ops.Pop();
                        if (top == "(")
                        {
                            found = true;
                            break;
                        }
                        output.Add(top);
                    }
                    if (!found) return null; // 괄호 불일치
                }
                else
                {
                    return null;
                }
            }

            while (ops.Count > 0)
            {
                var top = ops.Pop();
                if (top == "(" || top == ")") return null; // 괄호 불일치
                output.Add(top);
            }

            return output;
        }

        private int GetPrecedence(string op)
        {
            return op switch // 연산자 우선순위: +, -는 1, ×, ÷는 2
            {
                "+" => 1,
                "-" => 1,
                "×" => 2,
                "÷" => 2,
                _ => 0,
            };
        }
    }
}
