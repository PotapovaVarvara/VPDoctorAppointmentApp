import {Card, CardBody, InputGroup, InputLeftAddon, InputRightAddon, Stack, useDisclosure} from '@chakra-ui/react';
import { Text } from '@chakra-ui/react';
import { Button} from '@chakra-ui/react'
import axios from 'axios';
import { Select } from '@chakra-ui/react'
import {useEffect, useState} from "react";
import { Input } from '@chakra-ui/react'
import {
    Modal,
    ModalOverlay,
    ModalContent,
    ModalHeader,
    ModalFooter,
    ModalBody,
    ModalCloseButton,
} from '@chakra-ui/react'
import ScheduleSlider from "./ScheduleSlider.tsx";

export class SelectOptionItem{
    name: string;
    text: string;
}

export class ScheduleItem {
    day: string;
    timeStart: number;
    timeFinish: number;
}

export default function AddDoctorForm() {

    const [doctorSpecialityOptions, setDoctorSpecialityOptions] = useState([]);
    const [doctorScheduleDays, setDoctorScheduleDays] = useState([]);

    const [doctorSchedule, setDoctorSchedule] = useState<ScheduleItem[]>([]);
    const [doctorName, setDoctorName] = useState<string>("");
    const [doctorSurname, setDoctorSurname] = useState<string>("");
    const [doctorPhone, setDoctorPhone] = useState<string>("");
    const [doctorSpeciality, setDoctorSpeciality] = useState<number>(0);
    
    const { isOpen, onOpen, onClose } = useDisclosure();

    const fetchDoctorSpecialityOptions = async (): Promise<SelectOptionItem[]> => {
        try {
            const result = await axios.get('api/Doctor/GetDoctorSpecialitySelect');
            return result.data;
        } catch (error) {
            console.log(error);
        }
    }

    const fetchGetScheduleDays = async (): Promise<SelectOptionItem[]> => {
        try {
            const result = await axios.get('api/Doctor/GetScheduleDays');

            const scheduleItems = result.data.map((_)=>( {day: _.name, timeStart:8, timeFinish:16}));
            setDoctorSchedule(scheduleItems);
            return result.data;
        } catch (error) {
            console.log(error);
        }
    }
    
    useEffect(() => {
        (async () => {

            let doctorSpecialityOptions = await fetchDoctorSpecialityOptions();
            setDoctorSpecialityOptions(doctorSpecialityOptions);

            let doctorScheduleDays = await fetchGetScheduleDays();
            setDoctorScheduleDays(doctorScheduleDays);

        })();
    }, []);

    async function submitHandler() {
        await axios.post('api/Doctor/Add',
            {clientId:"7269b72b-83ce-4c8a-b06a-8307e3941a42",
                schedule: doctorSchedule,
                speciality: doctorSpeciality,
                user: {name:doctorName, surname:doctorSurname, phoneNumber: doctorPhone}},
            {
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json'
                }
            }
        );
    }

    const handleSliderValueChange = (value, index) => {
        const itemIndex = doctorSchedule.findIndex(_ => _.day == index);
        doctorSchedule[itemIndex].timeStart = value[0];
        doctorSchedule[itemIndex].timeFinish = value[1];
        
        //Log user input
        console.log(doctorSchedule);
        console.log(value);
        console.log(index);
    };


    return (
        <Card backgroundColor='#e8fcff' width="48%" mt={5} ml={5}  style={{display : 'inline-block',
            background: 'rgb(45,133,253, 0.1) linear-gradient(0deg, rgba(45,133,253,0.3) 19%, rgba(1,224,246, 0.1) 60%)',
        }}>
            <CardBody>
                <Input bg={"white"} placeholder="Ім'я лікаря" onChange={(event) => setDoctorName(event.target.value)}/>
                <Input mt={5} bg={"white"} placeholder="Прізвище лікаря" onChange={(event) => setDoctorSurname(event.target.value)}/>
                
                <Select mt={5} bg={"white"} placeholder='Спеціалізація лікаря' onChange={(event) => setDoctorSpeciality(Number(event.target.value))}>
                    {doctorSpecialityOptions.map((_, index) =>
                        (<option key={index} value={_.name}>{_.text}</option>))}
                </Select>


                <Stack mt={5} bg={"white"} spacing={4}>
                    <InputGroup>
                        <InputLeftAddon children='+380' />
                        <Input type='tel' placeholder='phone number' onChange={(event) => setDoctorPhone(event.target.value)}/>
                    </InputGroup>

                </Stack>
                
                <Button mt={5} onClick={onOpen}>Обрати графік роботи</Button>
                
                <div style ={{'marginTop':"50px"}}>
                    <Button mr={5}  colorScheme='blue' onClick={submitHandler}>Add doctor</Button>
                  
                </div>


                <Modal isOpen={isOpen} onClose={onClose} size = "2xl">
                    <ModalOverlay />
                    <ModalContent>
                        <ModalHeader>Modal Title</ModalHeader>
                        <ModalCloseButton />
                        <ModalBody>
                            {doctorScheduleDays.map((_, index) =>
                                (<div key = {index} >
                                        <Text textAlign={"center"} fontSize='md' key={"sliderText"+index}>{_.text}</Text>
                                        <ScheduleSlider key = {"slider"+index} index = {index} onInputValueChange={handleSliderValueChange}/></div>
                                ))}
                        </ModalBody>

                        <ModalFooter>
                            <Button colorScheme='blue' mr={3} onClick={onClose}>
                                Close
                            </Button>
                            <Button variant='ghost'>Secondary Action</Button>
                        </ModalFooter>
                    </ModalContent>
                </Modal>
            </CardBody>
        </Card>
    )
}