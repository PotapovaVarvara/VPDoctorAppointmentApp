import {
    Stat,
    StatLabel,
    StatNumber,
    StatHelpText,
    StatArrow, Card, CardBody, Text,
} from '@chakra-ui/react'
export default function StatisticsWidget() {

    return (
        <Card backgroundColor='#e8fcff' width="48%" mt={5} 
              style={{display : 'inline-block',
                  background: 'rgb(45,133,253, 0.1) linear-gradient(0deg, rgba(45,133,253,0.3) 19%, rgba(1,224,246, 0.1) 60%)',
           }}>
            <CardBody>
                <Stat>
                    <StatLabel>Collected Fees</StatLabel>
                    <StatNumber>£0.00</StatNumber>
                    <StatHelpText> 
                        <StatArrow type='increase' /> 23.36%</StatHelpText>
                </Stat>
                <Text>View a summary of all your customers over the last month.</Text>
            </CardBody>
        </Card>
    )
}