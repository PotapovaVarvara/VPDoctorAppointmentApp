import { Card, CardBody} from '@chakra-ui/react';
import { Text } from '@chakra-ui/react';
import { Button} from '@chakra-ui/react'
import axios from 'axios';
import { Select } from '@chakra-ui/react'

export default function Dashboard() {
    async function submitHandler() {
        await axios.post('api/Doctor/Add',
             {clientId:"7269b72b-83ce-4c8a-b06a-8307e3941a42", speciality: 0, user: {name:"Katy", surname:"Wilson"}},
            {
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json'
                }
            }
         );
    }

    return (
        <Card backgroundColor='#e8fcff' width="50%" mt={5}>
            <CardBody>
                <Select placeholder='Спеціалізація лікаря'>
                    <option value='0'>Option 1</option>
                    <option value='1'>Option 2</option>
                    <option value='2'>Option 3</option>
                </Select>
                
                <Text>View a summary of all your customers over the last month.</Text>
                <Button colorScheme='blue' onClick={submitHandler}>Add doctor</Button>
            </CardBody>
        </Card>
    )
}