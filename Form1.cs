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
                // 전체 식에 현재 입력 반영
                txtCalculate.Text = expression + txtResult.Text;
            }
            else
            {
                txtResult.Text += btn.Text;
                // 전체 식에 현재 입력 반영
                txtCalculate.Text = expression + txtResult.Text;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(txtResult.Text);

            // 보류중인 연산자가 있으면 현재 표시된 숫자에 적용
            if (op != 0)
            {
                // 보류중인 연산 수행
                ApplyOperation(op, num);
                // '=' 반복 눌렀을 때를 위해 기억
                lastOp = op;
                lastOperand = num;
                // 전체 식에 이번 항과 '=', 결과 추가
                expression += txtResult.Text + " = " + result.ToString();
                if (txtCalculate.Text != "Cannot divide by zero") txtCalculate.Text = expression;
                // 연산 완료로 보류 연산 초기화
                op = 0;
                // 식 초기화(다음 연산을 위해 결과를 시작값으로 사용)
                expression = "";
            }
            else if (lastOp != 0)
            {
                // '='를 반복 누르면 마지막 연산을 다시 수행
                double prev = result;
                ApplyOperation(lastOp, lastOperand);
                // 전체 식에 반복 연산 표시
                if (txtCalculate.Text != "Cannot divide by zero") txtCalculate.Text = prev.ToString() + " " + OpToString(lastOp) + " " + lastOperand.ToString() + " = " + result.ToString();
            }

            txtResult.Text = result.ToString();
            isClear = true;
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
                        txtCalculate.Text = "Cannot divide by zero";
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
            double num = Convert.ToDouble(txtResult.Text);

            if (op == 0)
            {
                // 보류중인 연산이 없으면 현재 숫자를 결과로 설정
                result = num;
                // 현재 입력된 숫자와 연산자를 식에 추가
                expression += txtResult.Text + " " + OpToString(newOp) + " ";
            }
            else
            {
                // 보류중인 연산을 즉시 적용
                ApplyOperation(op, num);
                // 보류중인 연산 뒤에 현재 항과 새 연산자를 추가
                expression += txtResult.Text + " " + OpToString(newOp) + " ";
            }

            // 다음 입력을 위해 준비
            txtResult.Text = result.ToString();
            isClear = true;
            op = newOp;
            // 새로운 연산 체인을 구성하므로 lastOp 초기화
            lastOp = 0;
            // 전체 식 표시 업데이트
            txtCalculate.Text = expression;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (isClear)
            {
                txtResult.Text = "0.";
                isClear = false;
                // 전체 식에 현재 입력 반영
                txtCalculate.Text = expression + txtResult.Text;
                return;
            }

            if (!txtResult.Text.Contains('.'))
            {
                txtResult.Text += ".";
                txtCalculate.Text = expression + txtResult.Text;
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

            // 전체 식 표시 갱신
            txtCalculate.Text = isClear ? expression : expression + txtResult.Text;
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
    }
}
